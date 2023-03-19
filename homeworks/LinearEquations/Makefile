DIR = $(HOME)/repos/PrakProg/matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@

Out.txt: main.exe
	mono $< > $@
main.exe: main.cs matrix.dll QRGS.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix.cs $(DIR)/vector.cs
	$(MKLIBF) $(DLLS)

#vector.dll: $(DIR)/vector.cs
#	$(MKLIBF) $(DLLS)

QRGS.dll: QRGS.cs matrix.dll
	$(MKLIB) $(DLLS)

clean:
	rm -f *.txt *.exe *.dll
