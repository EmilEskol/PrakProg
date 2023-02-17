using System;
using static System.Math;
using static System.Console;
static class stdin{
	static void Main(){
		char[] splitDelimeters={' ','\t','\n'};
		var splitOptions=StringSplitOptions.RemoveEmptyEntries;
		int calls=0;
		for(string line=ReadLine();line!=null;line=ReadLine()){
			var numbers = line.Split(splitDelimeters,splitOptions);
			foreach(var number in numbers){
				double x = double.Parse(number);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
				calls++;
			}
		}
	}
}
