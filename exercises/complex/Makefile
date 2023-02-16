Out.txt:main.exe
	mono main.exe > Out.txt
main.exe: main.cs cmath.dll
	mcs main.cs -target:exe -out:$@ -reference:cmath.dll
DIR = $(HOME)/repos/PrakProg/matlib/complex
cmath.dll: $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs $^ -target:library -out:./cmath.dll
clean:
	rm -f Out.txt main.exe cmath.dll
