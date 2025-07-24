(defpackage :logans-numeric-partition
  (:use :cl)
  (:export :categorize-number :partition-numbers))

(in-package :logans-numeric-partition)

(defun categorize-number (pair number)
  (let ((odds (car pair)) (evens (cdr pair)))
    (if (oddp number)
      (cons (cons number odds) evens)
      (cons odds (cons number evens)))))
  
(defun partition-numbers (numbers)
  (reduce #'categorize-number numbers :initial-value '(())))
