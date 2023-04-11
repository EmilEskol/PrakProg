DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKLIBF = mcs $^ -target:library -out:./$@
MKLIB = mcs $< -target:library -out:$@
MKDATA = mono $< > $@
MKEXE = mcs $< -target:exe -out:$@

Task: Out.txt LsPlot.svg

Out.txt: main.exe
	mono $< > $@
main.exe: main.cs matrix.dll LS.dll
	mcs $< -target:exe -out:$@ $(DLLS)

matrix.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs
	$(MKLIBF)
LS.dll: LS.cs matrix.dll
	$(MKLIB) $(DLLS)

LsPlot.svg: LsPlot.gpi ExpData.data DataFit.data
	gnuplot $< > $@
ExpData.data: ExpData.exe
	$(MKDATA)
ExpData.exe: ExpData.cs matrix.dll
	$(MKEXE) $(DLLS)
DataFit.data: DataFit.exe
	$(MKDATA)
DataFit.exe:DataFit.cs
	$(MKEXE)

clean:
	rm -f *.txt *.exe *.dll *.data *.svg
