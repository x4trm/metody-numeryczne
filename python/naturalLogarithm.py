from factorial import factorial
def e(n):
    e=0
    while n>=0:
        e+=(1/factorial(n))
        n=n-1
    return e