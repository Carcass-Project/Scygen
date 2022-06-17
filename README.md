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

If you are on linux, chances are that the Makefile can cover you. It might require editing as it isnt extensivly tested, but hopefully it will cover you. All operations need you to specify the project directory, and it will always output a *kernel.iso* as final product. There is a run command for QEMU aswell.
```sh
make all DIR="myproject" # Build myproject
make run DIR="myproject" # Run, this will build automatically!
make clean DIR="myproject" # Clean up build files! This does not remove the "limine" directory!
```