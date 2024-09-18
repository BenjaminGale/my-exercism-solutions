(defpackage :lucys-magnificent-mapper
  (:use :cl)
  (:export :make-magnificent-maybe :only-the-best))

(in-package :lucys-magnificent-mapper)

(defun make-magnificent-maybe (func numbers)
  (mapcar #'only-the-best numbers))

(defun only-the-best (func numbers)
  (remove 1 (remove-if func numbers)))