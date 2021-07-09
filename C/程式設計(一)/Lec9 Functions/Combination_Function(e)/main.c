#include<stdio.h>

int C(int a, int b)
{
    int ans;
    ans=1;
    if(a==0||a==b||b==0) return(ans);
    else if(a==1) return(b);
    else{
        ans=C(a-1,b-1)+C(a-1,b);
        return(ans);
    }
}

int main(){
    int n, m;
    scanf("%d %d", &n, &m);
    printf("%d", C(n,m));
    return 0;
}
