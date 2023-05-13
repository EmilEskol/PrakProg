DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = ReelErr.data EstErr.data val.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task: Out.txt 2Dplot.svg

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

2Dplot.svg: 2Dplot.gpi $(Data)
	gnuplot $< > $@
