#include<stdio.h>

int main(){
    int ch,l,i,j;
    scanf("%d \n",&l);
    int k[l];
    for(i=0;i<l;i++) k[i] = getchar() - 97;
    j=0;
    getchar();
    while((ch=getchar())!='\n'){
        if((ch>=65&&ch<=90)||(ch>=97&&ch<=122)){
            if ((ch<=(90-k[j%l]) && ch>=65) || (ch<=(122-k[j%l]) && ch>=97))
                printf("%c",ch+k[j%l]);
            else printf("%c",ch+k[j%l]-26);
            j++;
        }
        else{
            printf("%c", ch);
        }
    }

    return 0;
}
