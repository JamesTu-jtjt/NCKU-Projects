# CMAKE generated file: DO NOT EDIT!
# Generated by "MinGW Makefiles" Generator, CMake Version 3.17

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Disable VCS-based implicit rules.
% : %,v


# Disable VCS-based implicit rules.
% : RCS/%


# Disable VCS-based implicit rules.
% : RCS/%,v


# Disable VCS-based implicit rules.
% : SCCS/s.%


# Disable VCS-based implicit rules.
% : s.%


.SUFFIXES: .hpux_make_needs_suffix_list


# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2020.2.2\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2020.2.2\bin\cmake\win\bin\cmake.exe" -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = C:\Users\user\CLionProjects\Binary_Adder

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/Binary_Adder.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/Binary_Adder.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/Binary_Adder.dir/flags.make

CMakeFiles/Binary_Adder.dir/main.c.obj: CMakeFiles/Binary_Adder.dir/flags.make
CMakeFiles/Binary_Adder.dir/main.c.obj: ../main.c
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building C object CMakeFiles/Binary_Adder.dir/main.c.obj"
	C:\PROGRA~1\MINGW-~1\X86_64~1.0-P\mingw64\bin\gcc.exe $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -o CMakeFiles\Binary_Adder.dir\main.c.obj   -c C:\Users\user\CLionProjects\Binary_Adder\main.c

CMakeFiles/Binary_Adder.dir/main.c.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing C source to CMakeFiles/Binary_Adder.dir/main.c.i"
	C:\PROGRA~1\MINGW-~1\X86_64~1.0-P\mingw64\bin\gcc.exe $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -E C:\Users\user\CLionProjects\Binary_Adder\main.c > CMakeFiles\Binary_Adder.dir\main.c.i

CMakeFiles/Binary_Adder.dir/main.c.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling C source to assembly CMakeFiles/Binary_Adder.dir/main.c.s"
	C:\PROGRA~1\MINGW-~1\X86_64~1.0-P\mingw64\bin\gcc.exe $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -S C:\Users\user\CLionProjects\Binary_Adder\main.c -o CMakeFiles\Binary_Adder.dir\main.c.s

# Object files for target Binary_Adder
Binary_Adder_OBJECTS = \
"CMakeFiles/Binary_Adder.dir/main.c.obj"

# External object files for target Binary_Adder
Binary_Adder_EXTERNAL_OBJECTS =

Binary_Adder.exe: CMakeFiles/Binary_Adder.dir/main.c.obj
Binary_Adder.exe: CMakeFiles/Binary_Adder.dir/build.make
Binary_Adder.exe: CMakeFiles/Binary_Adder.dir/linklibs.rsp
Binary_Adder.exe: CMakeFiles/Binary_Adder.dir/objects1.rsp
Binary_Adder.exe: CMakeFiles/Binary_Adder.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking C executable Binary_Adder.exe"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\Binary_Adder.dir\link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/Binary_Adder.dir/build: Binary_Adder.exe

.PHONY : CMakeFiles/Binary_Adder.dir/build

CMakeFiles/Binary_Adder.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Binary_Adder.dir\cmake_clean.cmake
.PHONY : CMakeFiles/Binary_Adder.dir/clean

CMakeFiles/Binary_Adder.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" C:\Users\user\CLionProjects\Binary_Adder C:\Users\user\CLionProjects\Binary_Adder C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug C:\Users\user\CLionProjects\Binary_Adder\cmake-build-debug\CMakeFiles\Binary_Adder.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/Binary_Adder.dir/depend

