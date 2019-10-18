@echo off
echo requires nuitka
echo requires x86 Python2.7.15
echo RUN IN VS2017 COMMAND LINE

set PY27DIR=C:\Python27-86

%PY27DIR%\Scripts\nuitka  --standalone --show-progress --remove-output --python-flag=no_site make_fself.py

rd ..\GayMaker-Studio\bin\Debug\make_fself
rd ..\GayMaker-Studio\bin\Release\make_fself

mkdir ..\GayMaker-Studio\bin\Debug\make_fself
mkdir ..\GayMaker-Studio\bin\Release\make_fself

copy make_fself.dist\make_fself.exe ..\GayMaker-Studio\bin\Debug\make_fself
copy make_fself.dist\python27.dll ..\GayMaker-Studio\bin\Debug\make_fself

copy make_fself.dist\make_fself.exe ..\GayMaker-Studio\bin\Release\make_fself
copy make_fself.dist\python27.dll ..\GayMaker-Studio\bin\Release\make_fself

rd make_fself.dist /S /Q
