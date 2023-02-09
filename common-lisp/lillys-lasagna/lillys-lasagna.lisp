(defpackage :lillys-lasagna
  (:use :cl)
  (:export :expected-time-in-oven
           :remaining-minutes-in-oven
           :preparation-time-in-minutes
           :elapsed-time-in-minutes))

(in-package :lillys-lasagna)

(defun expected-time-in-oven ()
  "Calculates the expected time in the oven"
  337)

(defun remaining-minutes-in-oven (actual-minutes)
  "Calculates the remaining time in oven"
  (- (expected-time-in-oven) actual-minutes))

(defun preparation-time-in-minutes (number-of-layers)
  "Calculates the preparation time in minutes"
  (* 19 number-of-layers))

(defun elapsed-time-in-minutes (number-of-layers minutes-in-oven)
  "Calculates the elapsed time in minutes"
  (+ (preparation-time-in-minutes number-of-layers) minutes-in-oven))
