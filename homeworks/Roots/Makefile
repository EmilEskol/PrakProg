DIR = ../../matlib
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
Data = .data
Data2 = plainErr.data quasiErr.data val.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(Data) $(Data2)))
MKLIBF = mcs $(filter %.cs,$^) -target:library -out:./$@
MKLIB = mcs $(filter %.cs,$^) -target:library -out:$@
MKEXE = mcs $< -target:exe -out:$@

Task: Out.txt

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
$(Data): main.exe
main.exe: main.cs roots.dll matlib.dll IOput.dll
	$(MKEXE) $(DLLS)
matlib.dll: $(DIR)/matrix/matrix.cs $(DIR)/matrix/vector.cs $(DIR)/matrix/QRGS.cs $(DIR)/genlist.cs
	$(MKLIBF)
IOput.dll:$(DIR)/IOputs.cs matlib.dll
	$(MKLIBF) $(DLLS)
roots.dll: roots.cs matlib.dll
	$(MKLIB) $(DLLS)

partAplot.svg: partAplot.gpi $(Data)
	gnuplot $< > $@
partBplot.svg: partBplot.gpi $(Data2)
	gnuplot $< > $@

clean:
	rm -f *.svg *.dll *.exe Out.txt
