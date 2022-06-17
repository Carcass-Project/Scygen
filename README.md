# Scygen
Scygen is a operating system library kit, that makes your osdev life easier.
It's a collection of header files that help implement features that kernels have.
The libraries are open-source, and can be modified if you fork it.
I allow good pull requests to be merged into a different branch, and if everything works, I will merge it into the master branch.

# Tools
Scygen uses a few tools to make the "magic" happen:

  - NASM,
  - QEMU(Not included, but you must install it.),
  - clang++,
  - LLVM Linker(ld.lld)
  - xorriso,
  - GNU Make,
  - Chocolatey,
  - Limine.

# Contributing

You can always contribute to Scygen. Just make a fork, add your changes, and then make a pull request!

There are some rules your pull request must follow however:

  - Naming Rules for consistency(variables, functions must be in camelCase, and classes, structs, etc. in PascalCase),
  - No vulnerabilities,
  - Try to explain your code with comments.

# Installing

If you're on Windows, you need to use the ScygenSetup to install Scygen.
After you're done with that, you should also install QEMU, so you can run the kernel.

If you're on Linux, however, you have to install the tools that Scygen uses with your package manager, and then make a bash script that uses them in this way:

  1. Compile your C++ files with clang++.
  2. Assemble your assembly files with NASM with 64-bit ELF.
  3. Link them with ld.lld.
  4. Clone the Limine binaries(https://github.com/limine-bootloader/limine/tree/v3.5.4-binary)
  5. Run this `mkdir -p iso_root
	cp kernel/kernel.elf \
		limine.cfg limine/limine.sys limine/limine-cd.bin limine/limine-cd-efi.bin iso_root/`
  6. Run xorriso: `xorriso -as mkisofs -b limine-cd.bin \
		-no-emul-boot -boot-load-size 4 -boot-info-table \
		--efi-boot limine-cd-efi.bin \
		-efi-boot-part --efi-boot-image --protective-msdos-label \
		iso_root -o <output iso name>`
  7. Now use limine-deploy: `limine/limine-deploy barebones.iso`
  8. Make a HDD file for the VM for QEMU.
  9. Run QEMU.

It's complicated for Linux, but I'm hoping to fix that part soon.
