(defpackage :log-levels
  (:use :cl)
  (:export :log-message :log-severity :log-format))

(in-package :log-levels)

(defun log-message (log-string)
  (subseq log-string 8))

(defun log-level (log-string)
  (subseq log-string 1 5))

(defun log-severity (log-string)
  (let ((level (log-level log-string)))
       (cond ((string-equal level "info") :everything-ok)
             ((string-equal level "warn") :getting-worried)
             ((string-equal level "ohno") :run-for-cover))))
  

(defun log-format (log-string)
  (let ((severity (log-severity log-string)) (msg (log-message log-string)))
       (cond ((eq severity :everything-ok) (string-downcase msg))
             ((eq severity :getting-worried) (string-capitalize msg))
             ((eq severity :run-for-cover) (string-upcase msg)))))
