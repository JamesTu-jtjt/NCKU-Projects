#include<stdio.h>
#include<string.h>

char letters[26]={'A','B','C','D','E','F','G','H','I','J',
                  'K','L','M','N','O','P','Q','R','S','T',
                  'U','V','W','X','Y','Z'};

char sort(char *l, int len){
    int a=0;
    char nl[len+1];
    for (int i = 0; i < 26; i++) {
        for (int j = 0; j < len; j++) {
            if (letters[i] == l[j]) {
                nl[a]=l[j];
                a++;
                break;
            }
        }
    }
    for(int i=0; i<len; i++) l[i]=nl[i];
    return *l;
}

void permutation(char *str, int a, int len)
{
    char buff;
    if(a == len) printf("%s\n", str);
    else{
        for(int i=a; i<len; i++){
            if(i>1) {
                for (int j = 0; j < i-a; j++) {
                    buff = *(str + a + j);
                    *(str + a + j) = *(str + i);
                    *(str + i) = buff;
                }
                permutation(str, a + 1, len);
                for (int j = i-a-1; j >=0; j--) {
                    buff = *(str + a + j);
                    *(str + a + j) = *(str + i);
                    *(str + i) = buff;
                }
            }
            else {
                buff = *(str+a);
                *(str+a)=*(str+i);
                *(str+i)=buff;
                permutation(str, a+1, len);
                buff = *(str+a);
                *(str+a)=*(str + i);
                *(str+i)=buff;
            }
        }
    }
}

int main()
{
    char str[7];
    int len;
    scanf("%s", str);
    len = strlen(str);
    sort(str,len);
    permutation(str, 0, len);
    return 0;
}