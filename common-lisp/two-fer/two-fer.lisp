(defpackage :two-fer
  (:use :cl)
  (:export :twofer))
(in-package :two-fer)

(defun twofer (&optional (name nil))
  (format nil "One for ~a, one for me." (or name "you")))
