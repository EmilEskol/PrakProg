DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKDATA = mono $< > $@
MKEXE = mcs $< -target:exe -out:$@
DATA = ExpData.data DataFit.data DataFitU.data DataFitD.data
OUTPUTS = $(addprefix -output:,$(filter %.data,$(DATA)))

Task: Out.txt LsPlot.svg

Out.txt: main.exe
	mono $< $(OUTPUTS) > $@
main.exe: main.cs matrix.dll LS.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs $(DIR)/../IOputs.cs $(DIR)/../genlist.cs
	$(MKLIBF)
LS.dll: LS.cs matrix.dll
	$(MKLIB) $(DLLS)

LsPlot.svg: LsPlot.gpi ExpData.data DataFit.data
	gnuplot $< > $@
$(DATA):main.cs


clean:
	rm -f Out.txt *.exe *.dll *.data *.svg
