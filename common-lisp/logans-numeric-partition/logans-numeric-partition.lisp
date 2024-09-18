(defpackage :logans-numeric-partition
  (:use :cl)
  (:export :categorize-number :partition-numbers))

(in-package :logans-numeric-partition)

(defun categorize-number (pair number)
  (let ((odds (first pair)) (evens (rest pair)))
    (if (oddp number)
      ((cons number odds) . evens)
      (odds . (cons number evens)))))
  
(defun partition-numbers (numbers)
  (reduce #'categorize-number numbers :initial-value '(())))
