#include<stdio.h>

int main(){
    int a,b,i,n;
    scanf("%d %d", &a, &b);
    for(i=a;i<=b;i++){
        n=2;
        if (i==2||i==3) printf("%d ", i);
        else if (i>3){
            while(n<i){
                if(i%n==0) break;
                else n++;
                if (n==i/2+1) printf("%d ",i);
            }
        }
    }
    return 0;
}
