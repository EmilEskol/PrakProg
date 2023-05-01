DIR = ../../matlib
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = Erf.data erfTab.data
Data2 = ErfCompare1.data ErfCompare2.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data) $(Data2)))


Task: Out.txt Erf.svg ErfCompare.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
main.exe:main.cs Integ.dll matlib.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/IOputs.cs $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	$(MKLIB)
Integ.dll: Integ.cs
	$(MKLIB)

Erf.svg:Erf.gpi $(Data)
	gnuplot $< > $@


ErfCompare.svg:ErfCompare.gpi $(Data2)
	gnuplot $< > $@

$(Data) $(Data2):

clean:
	rm -f Out.txt *.svg *.dll *.exe *.data
