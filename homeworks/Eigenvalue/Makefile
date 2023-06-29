DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@

DATA = Rmax.data Delr.data TheoRmax.data TheoDelr.data Wavefunc.data TheoWavefunc.data
DATA2 =  Wavefunc.data Wavefunc1.data TheoWavefunc1.data TheoWavefunc.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(DATA) $(DATA2)))

Task: Out.txt ConRmax.svg ConDelr.svg Wavefunc.svg

Out.txt: main.exe
	mono $< -rmax:10 -dr:1 $(OUTPUTS) > $@

main.exe: main.cs matrix.dll EVD.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix.cs $(DIR)/../genlist.cs $(DIR)/../IOputs.cs $(DIR)/vector.cs
	$(MKLIBF)

EVD.dll: EVD.cs matrix.dll
	$(MKLIB) $(DLLS)

ConRmax.svg:ConRmax.gpi Rmax.data TheoRmax.data
	gnuplot $< > $@
ConDelr.svg:ConDelr.gpi Delr.data TheoDelr.data
	gnuplot $< > $@
Wavefunc.svg:Wavefunc.gpi $(DATA2)
	gnuplot $< > $@
$(DATA): main.cs
clean:
	rm -f Out.txt *.exe *.dll
