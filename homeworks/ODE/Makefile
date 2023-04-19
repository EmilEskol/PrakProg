DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
OUTPUTS = $(addprefix -output:,$(filter %.data,$^))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task:Oscilation.svg Out.txt

Out.txt: main.exe Oscilation.data
	mono $< $(OUTPUTS) > $@
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
Oscilation.data:
