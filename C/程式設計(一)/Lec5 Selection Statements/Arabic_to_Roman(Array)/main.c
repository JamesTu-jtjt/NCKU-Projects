#include <stdio.h>

int main() {
    int i,j,a1, a[7];
    char  r[7]={'M', 'D', 'C', 'L', 'X', 'V', 'I' };
    scanf("%d",&a1);
    for(i=6;i>0;i-=2){
        a[i-1]=(a1%10)/5;
        a[i]=a1%5;
        a1/=10;
    }
    for(i=a1;i>0;i--) printf("%c", r[0]);
    for(i=1;i<=6;i++){
        if(a[i+1]==4){
            if(a[i]==1) printf("%c%c",r[i+1],r[i-1]);
            else printf("%c%c",r[i+1],r[i]);
        }
        else if(a[i]==4) continue;
        else
            for(j=a[i];j>0;j--) printf("%c", r[i]);
    }
    return 0;
}

