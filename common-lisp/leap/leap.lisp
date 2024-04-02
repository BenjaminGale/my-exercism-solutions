(defpackage :leap
  (:use :cl)
  (:export :leap-year-p))
(in-package :leap)

(defun leap-year-p (year)
  (or 
   (and 
    (is-divisible-by year 4) 
    (not (is-divisible-by year 100)))
   (is-divisible-by year 400)))

(defun is-divisible-by (num div)
  (zerop (mod num div)))
