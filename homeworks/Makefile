DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = Oscilation.data scipyPlot.data scipyPlot2.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
$(Data): main.exe
main.exe: main.cs monteCarlo.dll matlib.dll IOput.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	$(MKLIBF)
IOput.dll:$(DIR)/IOputs.cs matlib.dll
	$(MKLIBF) $(DLLS)
monteCarlo.dll: monteCarlo.cs matlib.dll
	$(MKLIB) $(DLLS)
