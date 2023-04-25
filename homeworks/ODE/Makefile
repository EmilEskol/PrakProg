DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = Oscilation.data scipyPlot.data scipyPlot2.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task:Out.txt Oscilation.svg scipyPlot.svg scipyPlot2.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
$(Data): main.exe
main.exe: main.cs ODE.dll matlib.dll IOput.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	$(MKLIBF)
IOput.dll:$(DIR)/IOputs.cs matlib.dll
	$(MKLIBF) $(DLLS)
ODE.dll: ODE.cs matlib.dll
	$(MKLIB) $(DLLS)


Oscilation.svg:Oscilation.gpi Oscilation.data
	gnuplot $< > $@
scipyPlot.svg:scipyPlot.gpi scipyPlot.data
	gnuplot $< > $@
scipyPlot2.svg:scipyPlot2.gpi scipyPlot2.data
	gnuplot $< > $@


clean:
	rm -f Out.txt *.svg *.dll *.exe *.data
