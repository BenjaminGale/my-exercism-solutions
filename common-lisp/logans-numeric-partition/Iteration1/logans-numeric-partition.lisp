(defpackage :logans-numeric-partition
  (:use :cl)
  (:export :categorize-number :partition-numbers))

(in-package :logans-numeric-partition)

(defun categorize-number (pair number)
  (if (oddp number)
      (cons (append (list number) (car pair)) (cdr pair))
      (cons (car pair) (append (list number) (cdr pair)))))

(defun partition-numbers (numbers)
  (reduce #'categorize-number numbers :initial-value '(())))
