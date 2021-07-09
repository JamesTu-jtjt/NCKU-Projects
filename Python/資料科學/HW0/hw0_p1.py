###PROBLEM 1
#function to put the polynomial text into lists
def polynomial_Expressions(input_):
    #define non polynomials and initialization of return values
    n,l,p = ['0','1','2','3','4','5','6','7','8','9','^','+','-','*','(',')'],[],[]
    #determine polynomial variables
    for i in input_:
        if (i not in n) and (i not in p): p.append(i)
    #put polynomial expressions into lists and remove brackets
    input_=input_.strip('()').split(')(')
    #put each polynomial of each expression in nested list then append result to L
    for expr in input_:    
        expr=expr.replace('-', '+-').split('+')
        for poly in range(len(expr)):
            if expr[poly].count('^') >= 1:
                e = expr[poly][expr[poly].find('^')+1]
                expr[poly] = expr[poly].replace('^'+e, expr[poly][expr[poly].find('^')-1]*(int(e)-1))
        l.append(expr)
    #return list of polynomials and expressions
    return (l, p)


#function to find coefficients
def find_Coef(list_):
    #find coefficients of polynomials and separate them
    for i in range(len(list_)):
        for j in range(len(list_[i])):
            list_[i][j] = list_[i][j].split('*') if list_[i][j].count('*') == 1 else ['1', list_[i][j]]
    #find signs of coefficients
    for i in range(len(list_)):
        for j in range(len(list_[i])):
            if list_[i][j][1].count('-')%2 == 1:
                list_[i][j][0] = str(-int(list_[i][j][0]))
                list_[i][j][1] = ''.join(list_[i][j][1].split('-'))
    #return List after modification
    return list_


#recursive function to multiply 2 expressions at a time and return list of each polynomial
def multiplication(list_):
    #initialization of return value
    l = []
    #find each combination of polynomials and append to list L
    for i in list_[0]:
        for j in list_[1]:
            l.append([int(i[0])*int(j[0]), i[1]+j[1]])
    #append L to original list and delete the first 2 expressions
    list_.append(l)
    del list_[0:2]
    #recursive function set to call itself when the number of expressions > 1 and return List when expressions = 1
    return l if len(list_) == 1 else multiplication(list_)


#function used to format calculation to print result
def denotation(list_, poly):
    #initialization of list for checking and formatting result
    c = []
    for i in range(len(list_)):
        #flag initialization
        flag=False
        #check exponents by counting (using List poly to determine rank of variables)
        for j in poly:
            if list_[i][1].count(j) > 1:
                temp = j + '^' + str(list_[i][1].count(j))
                list_[i][1] = list_[i][1].replace(j, '')
                list_[i][1] += temp
            elif list_[i][1].count(j) == 1: 
                list_[i][1] = list_[i][1].replace(j, '')
                list_[i][1] += j
        #check for repeated polynomials
        for check in c:
            if check[1] == list_[i][1]:
                check[0] += list_[i][0]
                flag = True
        if not flag: c.append(list_[i])
    print(c)
    #initialize result
    result = ""
    #format result
    for i in range(len(c)):
        if (i != len(c)-1) and (c[i+1][0] > 0): c[i][1] += "+" 
        c[i][0] = str(c[i][0]) + "*"
        if c[i][0].count('1') == 1: c[i][0] = c[i][0].replace('1*', '')
        result += c[i][0] + c[i][1]
    print(result)


#allow input of polynomial text
input_ = input("Input the polynomials: ")
#call previously defined functions to give result
l,p=polynomial_Expressions(input_)
denotation(multiplication(find_Coef(l)),p)

 
###BONUS
#modify previous functions
#the multiplication function doesn't have to be modified
#function to put the polynomial text into lists
def polynomial_Expressions_B(input_):
    #define non polynomials and initialization of return values
    n,l,p = ['0','1','2','3','4','5','6','7','8','9','+','-','(',')'],[],[]
    #determine polynomial variables
    for i in input_:
        if (i not in n) and (i not in p): p.append(i)
    #put polynomial expressions into lists and remove brackets
    input_=input_.strip('()').split(')(')
    #put each polynomial of each expression in nested list then append result to L
    for expr in input_:    
        expr=expr.replace('-', '+-').split('+')
        for poly in range(len(expr)):
            for i in range(len(expr[poly])-1):
                if (expr[poly][i] in p) and (expr[poly][i+1] in ['2','3','4','5','6','7','8','9']): 
                    expr[poly] = expr[poly].replace(expr[poly][i:i+2], expr[poly][i]*(int(expr[poly][i+1])))
        l.append(expr)
    #return list of polynomials and expressions
    return (l, p) 


#function to find coefficients
def find_Coef_B(list_):
    #find signs of coefficients
    #find coefficients of polynomials
    for i in range(len(list_)):
        for j in range(len(list_[i])):
            list_[i][j] = [-1, list_[i][j][1:]] if list_[i][j].count('-')%2 == 1  else [1, list_[i][j]]
            coef = 0
            for k in list_[i][j][1]: 
                if k in ['2','3','4','5','6','7','8','9']: coef+=1
            if coef > 0:
                list_[i][j][0] = str(list_[i][j][0]*int(list_[i][j][1][0:coef]))
                list_[i][j][1] = list_[i][j][1][coef:]
    #return List after modification
    return list_


#function used to format calculation to print result
def denotation_B(list_, poly):
    #initialization of list for checking and formatting result
    c = []
    for i in range(len(list_)):
        #flag initialization
        flag=False
        #check exponents by counting (using List poly to determine rank of variables)
        for j in poly:
            if list_[i][1].count(j) > 1:
                temp = j + str(list_[i][1].count(j))
                list_[i][1] = list_[i][1].replace(j, '')
                list_[i][1] += temp
            elif list_[i][1].count(j) == 1: 
                list_[i][1] = list_[i][1].replace(j, '')
                list_[i][1] += j
        #check for repeated polynomials
        for check in c:
            if check[1] == list_[i][1]:
                check[0] += list_[i][0]
                flag = True
        if not flag: c.append(list_[i])
    print(c)
    #initialize result
    result = ""
    #format result
    for i in range(len(c)):
        if (i != len(c)-1) and (c[i+1][0] > 0): c[i][1] += "+" 
        c[i][0] = str(c[i][0])
        if c[i][0].count('1') == 1: c[i][0] = c[i][0].replace('1', '')
        result += c[i][0] + c[i][1]
    print(result)


input_b = input("Input the Polynomials (Bonus): ")
l_b, p_b = polynomial_Expressions_B(input_b)
denotation_B((multiplication(find_Coef_B(l_b))),p_b)



