using System;
//using static genlist;
using static System.Console;

static class main{
	static void Main(){
	var listD= new genlist<double>();
	char delimiters={' ','\t','\n'};
	var options = StringSplitOptions.RemoveEmptyEntries;
	for(string line = ReadLine();line!=null; line = ReadLine()){
		var words = line.Split(delimiters,options);
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++){
			numbers[i] = double.Parse(words[i]);
			listD.add(numbers[i]);
			}
		}
	for(int i=0;i<listD.size;i++){	
		foreach(var number in listD){Write($"{number : 0.00e+00;-0.00e+00}");}
		WriteLine();
		}
	}
}
