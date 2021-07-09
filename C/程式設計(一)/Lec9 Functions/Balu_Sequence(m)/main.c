#include<stdio.h>

 long long int B(int i)
{
    if(i<=2) return 1;
    else return (2*B(i-1)+3*B(i-2))%1000000007;
}

int main(){
    int a;
    scanf("%d",&a);
    printf("%lld",B(a));
    return 0;
}