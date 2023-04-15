DIR = ../../matlib/matrix
DLLS = $(addprefic -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $^ -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Out.txt: main.exe
	mono $< > $@
main.exe: main.cs Spline.dll
	$(MKEXE) $(DLLS)
Spline.dll: Spline.cs
	$(MKLIB)


clean:
	rm -f *.txt *.exe *.dll
