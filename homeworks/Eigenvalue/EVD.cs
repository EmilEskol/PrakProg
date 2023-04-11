using static matrix;
using static System.Console;
using static System.Math;

public static class EVD{
	public static void timesJ(matrix A, int p,int q,double theta){
		double c=Cos(theta),s=Sin(theta);
		for(int i=0;i<A.size1;i++){
			double Aip=A[i,p],Aiq=A[i,q];
			A[i,p]=c*Aip-s*Aiq;
			A[i,q]=s*Aip+c*Aiq;
		}
	}
	public static void Jtimes(matrix A, int p,int q,double theta){
		double c=Cos(theta),s=Sin(theta);
		for(int i=0;i<A.size1;i++){
			double Api=A[p,i],Aqi=A[q,i];
			A[p,i]=c*Api+s*Aqi;
			A[q,i]=-s*Api+c*Aqi;
		}
	}
	public static (matrix,vector)  Eigen(matrix M){
		int n=M.size1;
		matrix A=M.copy();
		matrix V=matrix.id(n);
		vector w=new vector(n);
		bool changed;
		do{
			changed=false;
			for(int p=0;p<n-1;p++){
				for(int q=p+1;q<n;q++){
					double Apq=A[p,q], App=A[p,p],Aqq=A[q,q];
					double theta=0.5*Atan2(2*Apq,Aqq-App);
					double c=Cos(theta),s=Sin(theta);
					double new_App=c*c*App-2*s*c*Apq+s*s*Aqq;
					double new_Aqq=s*s*App+2*s*c*Apq+c*c*Aqq;
					if(new_App!=App  || new_Aqq!=Aqq){
						changed=true;
						timesJ(A,p,q,theta);
						Jtimes(A,p,q,-theta);
						timesJ(V,p,q, theta);
					}
				}
			}
		}while(changed);
		for(int i=0;i<n;i++)
			w[i]=A[i,i];
		return (V,w);
	}
}
