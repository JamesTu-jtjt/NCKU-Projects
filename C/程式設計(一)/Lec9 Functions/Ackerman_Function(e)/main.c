#include<stdio.h>

int A(int a, int b)
{
    int ans,ans1;
    if(a==0) return(b+1);
    else if(b==0) return(A(a-1,1));
    else return(A(a-1,A(a,b-1)));
}

int main(){
    int n,m;
    scanf("%d %d", &n, &m);
    printf("%d",A(n,m));
    return 0;
}
