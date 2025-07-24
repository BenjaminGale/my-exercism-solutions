use std::collections::HashMap;
use std::collections::HashSet;

pub struct School {
    students: HashMap<String, u32>
}

impl School {
    
    pub fn new() -> School {
        School {
            students: HashMap::new()
        }
    }

    pub fn add(&mut self, grade: u32, student: &str) {
        if !self.students.contains_key(student) {
            self.students.insert(student.to_owned(), grade);
        }
    }

    pub fn grades(&self) -> Vec<u32> {
        let mut unique_grades: Vec<u32> = self
            .students
            .values()
            .cloned()
            .collect::<HashSet<u32>>()
            .into_iter()
            .collect();
        
        unique_grades.sort();
        unique_grades
    }

    // If `grade` returned a reference, `School` would be forced to keep a `Vec<String>`
    // internally to lend out. By returning an owned vector of owned `String`s instead,
    // the internal structure can be completely arbitrary. The tradeoff is that some data
    // must be copied each time `grade` is called.
    pub fn grade(&self, grade: u32) -> Vec<String> {
        let mut students = Vec::new();

        for (student, student_grade) in self.students.iter() {
            if *student_grade == grade {
                students.push(student.clone());
            }
        }
        
        students.sort();
        students
    }
}
