(defpackage :lillys-lasagna-leftovers
  (:use :cl)
  (:export
   :preparation-time
   :remaining-minutes-in-oven
   :split-leftovers))

(in-package :lillys-lasagna-leftovers)

;; Define function preparation-time
(defun preparation-time (&rest rest)
  (* (length rest) 19))

;; Define function remaining-minutes-in-oven
(defun remaining-minutes-in-oven (&optional (duration nil duration-supplied-p))
  (if duration-supplied-p
    (case duration
      ((nil) 0)
      (:normal 337)
      (:shorter 237)
      (:very-short 137)
      (:longer 437)
      (:very-long 537))
    337))

;; Define function split-leftovers
(defun split-leftovers (&key (weight nil weight-supplied-p) (human 10) (alien 10))
  (if weight-supplied-p
    (if weight
      (- weight human alien)
      :looks-like-someone-was-hungry)
    :just-split-it))
