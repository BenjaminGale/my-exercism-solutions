(defpackage :anagram
  (:use :cl)
  (:export :anagrams-for))

(in-package :anagram)

(defun anagrams-for (subject candidates)
  "Returns a sublist of candidates which are anagrams of the subject."
  (remove-if-not (lambda (candidate) (anagramp subject candidate)) candidates))

(defun anagramp (a b)
  "Returns true if a and b are anagrams"
  (let ((a (string-downcase a))
        (b (string-downcase b)))
       (and 
        (not (string-equal a b))
        (string= 
         (sort a #'char-lessp)
         (sort b #'char-lessp)))))
