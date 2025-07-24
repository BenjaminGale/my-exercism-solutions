(defpackage :hamming
  (:use :cl)
  (:export :distance))

(in-package :hamming)

(defun distance (dna1 dna2)
  "Number of positional differences in two equal length dna strands."
  (when (eq (length dna1) (length dna2))
      (count t (map 'list (lambda (a b) (unless (eq a b) t)) dna1 dna2))))
