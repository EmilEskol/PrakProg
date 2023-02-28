using static System.Console;
using static System.Math;

static class lnfactorial{
	public static void Main(){
		for(int i=0;i<=14;i++)
			WriteLine($"{i}	{Log(fact(i))}");
	}
	public static long fact(int i){
		if(i==0) return 1;
		long result=1;
		for(int n=1;n<=i;n++)
			result*=n;
		return result;
	}
}
