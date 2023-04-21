using System;

public class Spline{
	public static double linterp(double[]x, double[] y, double z){
		int i=binSearch(x,z);
		double dx=x[i+1]-x[i]; 
		if(dx<=0) 
			throw new Exception("dx=<0");
		double dy=y[i+1]-y[i];
		return y[i]+dy/dx*(z-x[i]);
	}
	public static int binSearch(double[] x, double z){
		int i=0,j=x.Length-1;
		if(z<x[0] || z>x[j])
			throw new Exception("Out of bounds z");
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>mid)
				i=mid;
			else
				j=mid;
			}
		return i;
	}
	public static double linterpInteg(double[] x, double[] y, double z){
		int i=binSearch(x,z);
		double result=0;
		for(int j=0;j<i;j++){
			result+=(y[j]+y[j+1])/2*(x[j+1]-x[j]);
		}
		result+=(y[i]+linterp(x,y,z))/2*(z-x[i]);
		return result;
	}
}
