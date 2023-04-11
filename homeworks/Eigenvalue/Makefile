DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll EVD.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix.cs $(DIR)/vector.cs
	$(MKLIBF)

EVD.dll: EVD.cs matrix.dll
	$(MKLIB) $(DLLS)

clean:
	rm -f *.txt *.exe *.dll
