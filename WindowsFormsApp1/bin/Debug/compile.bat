@echo off
title PICO IDE Compiler
echo Compiling your code...
DEL .\output\compiled_app.exe >nul
tcc.exe .\\output\\compiled_app.c
move .\\compiled_app.exe .\\output\\ >nul
DEL .\output\compiled_app.c >nul
PAUSE
cd output
start .