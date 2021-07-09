#include <stdio.h>
#include <string.h>
#include <stdlib.h>

struct element {                        // elements of the stack
    int data;
    struct element *next;   // point to the next element in the stack
};

struct head {
    int size;                               // record the size of the stack
    struct element *next;   // point to the first element (at bottom) in the stack if there is any
    struct element *top;    // point to the top of the stack
};

void print_stack(struct head *stack_p) {
    printf("%d\n", stack_p->size);
    for (struct element *ptr = stack_p->next; ptr != NULL; ptr = ptr->next)
        printf("%d ", ptr->data);
}

void push(struct head *stack_p, int data) {
    // create an element and push it to the top of the stack
    struct element *new;
    new=malloc(sizeof(struct element));
    new->data=data;
    new->next=NULL;
    if(stack_p->next==NULL) stack_p->next=new;
    else stack_p->top->next=new;
    stack_p->top=new;
    stack_p->size++;
}

struct element* pop(struct head *stack_p) {
    // return the element which is popped from the stack
    struct element *p;
    p=stack_p->top;
    if(stack_p->next==p){
        stack_p->next = NULL;
        stack_p->top = NULL;
    }
    else {
        for (struct element *ptr = stack_p->next; ptr != NULL; ptr = ptr->next)
            if(ptr->next==p){
                ptr->next=NULL;
                stack_p->top=ptr;
            }
    }
    stack_p->size--;
    return p;
}

int main(void) {
    // stack declaration
    struct head stack_head;
    stack_head.size = 0;
    stack_head.next = NULL;
    stack_head.top = NULL;

    // read instructions
    int num, data;
    char command[5];
    scanf("%d", &num);
    for (int i = 0; i < num; ++i) {
        scanf("%4s", command);
        if (strcmp(command, "push") == 0) {     // push command, call push()
            scanf("%d", &data);
            push(&stack_head, data);
        }
        else if (strcmp(command, "pop") == 0) { // pop command, call pop()
            struct element *e = pop(&stack_head);
            free(e);
        }
    }
    print_stack(&stack_head);
    return 0;
}
