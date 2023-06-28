DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = Solution.data Estimate.data
Data2 = ConRmax.data  ConRmin.data ConAcc.data ConEps.data 
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data) $(Data2)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task: Out.txt partBplot.svg ConvergRmin.svg ConvergRmax.svg ConvergAcc.svg ConvergEps.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
main.exe: main.cs roots.dll matlib.dll IOput.dll
	$(MKEXE) $(DLLS)
$(Data) $(Data2):main.exe

matlib.dll: $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/matrix/ODE.cs $(DIR)/matrix/QRGS.cs $(DIR)/genlist.cs
	$(MKLIBF)
IOput.dll:$(DIR)/IOputs.cs matlib.dll
	$(MKLIBF) $(DLLS)
roots.dll: roots.cs matlib.dll
	$(MKLIB) $(DLLS)


partBplot.svg: partB.gpi $(Data)
	gnuplot $< > $@
ConvergRmin.svg: ConRmin.gpi $(Data2)
	gnuplot $< > $@
ConvergRmax.svg: ConRmax.gpi $(Data2)
	gnuplot $< > $@
ConvergAcc.svg: ConAcc.gpi $(Data2)
	gnuplot $< > $@
ConvergEps.svg: ConEps.gpi $(Data2)
	gnuplot $< > $@

clean:
	rm -f *.svg *.dll *.exe Out.txt
