DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = valPartA.data ANNresPartA.data ANNresPartA1.data ANNresPartA2.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task: Out.txt partAplot.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
main.exe: main.cs ANN.dll matlib.dll IOput.dll
	$(MKEXE) $(DLLS)
$(Data):main.exe

matlib.dll: $(DIR)/matrix/*.cs $(DIR)/genlist.cs
	$(MKLIBF)
IOput.dll:$(DIR)/IOputs.cs matlib.dll
	$(MKLIBF) $(DLLS)
ANN.dll: ANN.cs matlib.dll IOput.dll
	$(MKLIB) $(DLLS)

partAplot.svg: partA.gpi $(Data)
	gnuplot $< > $@

clean:
	rm -f *.svg *.dll *.exe *.data Out.txt
