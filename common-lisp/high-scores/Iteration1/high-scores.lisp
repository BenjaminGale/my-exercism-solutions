(defpackage :high-scores
  (:use :cl)
  (:export :make-high-scores-table :add-player
           :set-score :get-score :remove-player))

(in-package :high-scores)

(defun make-high-scores-table ()
  (make-hash-table))

(defun add-player (hash-table name)
  (setf (gethash name hash-table) 0))

(defun set-score (hash-table name score)
  (setf (gethash name hash-table) score))

(defun get-score (hash-table name)
  (gethash name hash-table 0))

(defun remove-player (hash-table name)
  (remhash name hash-table))
