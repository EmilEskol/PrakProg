DIR = ../../matlib
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = Erf.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data)))


Task: Out.txt Erf.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
main.exe:main.cs Integ.dll matlib.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/IOputs.cs $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	$(MKLIB)
Integ.dll: Integ.cs
	$(MKLIB)

Erf.svg:Erf.gpi $(Data) erfTab.data
	gnuplot $< > $@
erfTab.data: erfTab.exe
	mono $< > $@
erfTab.exe: ../../exercises/plots/erfTabData.cs
	mcs $< -target:exe -out:$@
$(Data):

clean:
	rm -f Out.txt *.svg *.dll *.exe *.data
