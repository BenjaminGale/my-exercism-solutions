
pub const TriangleError = error{
    Invalid,
};

pub const Triangle = struct {
    a: f64,
    b: f64,
    c: f64,

    pub fn init(a: f64, b: f64, c: f64) TriangleError!Triangle {
        if (!isValid(a, b, c)) {
            return TriangleError.Invalid;
        }
    
        return Triangle {
            .a = a,
            .b = b,
            .c = c,
        };
    }

    fn isValid(a: f64, b: f64, c: f64) bool {
        return a > 0 and
               b > 0 and
               c > 0 and
               a + b >= c and
               b + c >= a and
               a + c >= b;
    }

    pub fn isEquilateral(self: Triangle) bool {
        return self.a == self.b and self.b == self.c and self.c == self.a;
    }

    pub fn isIsosceles(self: Triangle) bool {
        return self.a == self.b or self.b == self.c or self.c == self.a;
    }

    pub fn isScalene(self: Triangle) bool {
        return self.a != self.b and self.a != self.c and self.c != self.b;
    }
};
