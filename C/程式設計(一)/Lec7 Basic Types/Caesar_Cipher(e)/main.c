#include<stdio.h>

int main(){
    int ch, k;
    scanf("%d \n",&k);
    k=k%26;
    while((ch=getchar())!='\n'){
        if((ch>=65&&ch<=90)||(ch>=97&&ch<=122)){
            if(k>0){
                if ((ch<=(90-k) && ch>=65) || (ch<=(122-k) && ch>=97))
                    printf("%c",ch+k);
                else printf("%c",ch+k-26);
            }
            else if(k<0){
                if ((ch>=(65-k) && ch<=90) || (ch>=(97-k) && ch>=97))
                    printf("%c",ch+k);
                else printf("%c",ch+k+26);
            }
            else printf("%c",ch);
        }
        else printf("%c",ch);
    }

    return 0;
}

