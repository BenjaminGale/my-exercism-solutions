(defpackage :rna-transcription
  (:use :cl)
  (:export :to-rna))
(in-package :rna-transcription)

(defun to-rna (dna)
  "Transcribe a string representing DNA nucleotides to RNA."
  (coerce (mapcar #'map-nucleotide (coerce dna 'list)) 'string))

(defun map-nucleotide (nucleotide)
  (case nucleotide
    (#\G #\C)
    (#\C #\G)
    (#\T #\A)
    (#\A #\U)
    (t (error "Invalid nucleotide found: ~a" nucleotide))))
