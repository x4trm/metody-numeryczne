class Complex():
    def __init__(self,re,im=0.0):
        self.re=re
        self.im=im
    def __add__(self,other):
        return Complex(self.re+other.re,self.im+other.im)
    def __mul__(self,other):
        return Complex(self.re*other.re-self.im*other.im, self.im*other.re+self.re*other.im)
    def __str__(self):
        if self.im<0:
            return f"{self.re}{self.im}i"
        return f"{self.re}+{self.im}i"