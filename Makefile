## Scygen makefile made by khhs167 because i was triggered
## Please enjoy mess

rwildcard=$(foreach d,$(wildcard $(1:=/*)),$(call rwildcard,$d,$2) $(filter $(subst *,%,$2),$d))

.PHONY: limine kernel iso all run clean

ifndef DIR
$(error "No project directory specified!")
endif

VALID_DIR := $(shell if [ -f $(DIR)/*.scyproj ]; then echo "ok"; fi)

ifeq ($(VALID_DIR),)
$(error "Project not valid!")
endif

CXX?=clang++

CXX_FLAGS = -ffreestanding -fno-builtin -nostdlib -nostdinc -nostdinc++

CPP_SRC = $(call rwildcard,$(DIR),*.cpp)
ASM_SRC = $(call rwildcard,$(DIR),*.asm)
OBJECTS = $(CPP_SRC:.cpp=.o) $(ASM_SRC:.asm=.o)

%.o: %.cpp
	$(CXX) -c $< -o $@ $(CXX_FLAGS)

%.o: %.asm
	nasm -elf64 $< -o $@

kernel: ${OBJECTS}
	$(LD) -o $(DIR)/kernel.elf $< 

limine:
	if [ ! -d "limine" ]; then git clone https://github.com/limine-bootloader/limine.git -b v3.5.4-binary; fi
	cc limine/limine-deploy.c -o limine/limine-deploy

iso_root: limine kernel
	mkdir -p iso_root 
	cp $(DIR)/kernel.elf $(DIR)/limine.cfg limine/limine.sys limine/limine-cd.bin limine/limine-cd-efi.bin iso_root/

iso: iso_root
	xorriso -as mkisofs -b limine-cd.bin \
        -no-emul-boot -boot-load-size 4 -boot-info-table \
        --efi-boot limine-cd-efi.bin \
        -efi-boot-part --efi-boot-image --protective-msdos-label \
        iso_root -o $(DIR)/kernel.iso
	./limine/limine-deploy $(DIR)/kernel.iso
	rm -rf iso_root

all: iso

run: all
	qemu-system-x86_64 -cdrom $(DIR)/kernel.iso -serial stdio -cpu kvm64

clean:
	$(RM) -f ${OBJECTS} $(DIR)/kernel.elf $(DIR)/kernel.iso