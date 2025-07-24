(defpackage :beer-song
  (:use :cl)
  (:export :verse :sing))

(in-package :beer-song)

(defun verse (n)
  "Returns a string verse for a given number."
  (format nil "~a~%~a~%" (line-1 n) (line-2 n)))

(defun line-1 (n)
  (cond
    ((> n 0) (format nil "~a bottle~:p of beer on the wall, ~:*~a bottle~:p of beer." n))
    (t "No more bottles of beer on the wall, no more bottles of beer.")))

(defun line-2 (n)
  (cond
    ((> n 1) (format nil "Take one down and pass it around, ~a bottle~:p of beer on the wall." (1- n)))
    ((eq 1 n) "Take it down and pass it around, no more bottles of beer on the wall.")
    ((eq 0 n) "Go to the store and buy some more, 99 bottles of beer on the wall.")))

(defun sing (start &optional (end 0))
  "Returns a string of verses for a given range of numbers."
  (format nil "~{~a~%~}"
          (loop :for i :downfrom start :to end
                :collect (verse i))))
