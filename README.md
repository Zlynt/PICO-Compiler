# PICO Compiler
Professor: Leonel Nóbrega

Students:
- Ivan Teixeira
- Carolina Sousa

## Introduction
Our professor proposed the development of a PICO language compiler. The PICO language was developed by J.A. Bergstra.

## Features
- Find errors in the source code
- Compile the Source Code
- Extended PICO Syntax
   - Support for "if", "if else" and "for" cycles

## Why C#?
We chose C# due to its compatibility with Gold Parser. The second reason was to use the .NET framework to build our GUI.

## How it works
- First, we check for errors in the user's source code with Calitha Engine
- Then, a parsing tree is generated using a method (provided by the Calitha Engine) called "LALRParser.AcceptHandler".
- If the parsing tree is generated with success, we unlock the compile feature for the user
- For compilation, we first translate our PICO code to "C" code
- After the translation, the code is compiled into an executable binary

# Type verification
To verify the variable types:
- We first detect the variables declared using the "declare"
- Then while the parsing tree is built, we check if the variables only have one type associated with it.

