(defpackage :hamming
  (:use :cl)
  (:export :distance))

(in-package :hamming)

(defun distance (dna1 dna2)
  "Number of positional differences in two equal length dna strands."
  (if (eq (length dna1) (length dna2))
      (reduce #'+ (mapcar #'distance-single (coerce dna1 'list) (coerce dna2 'list)) :initial-value 0)
      nil))

(defun distance-single (dna1 dna2)
  (if (eq dna1 dna2) 0 1))
