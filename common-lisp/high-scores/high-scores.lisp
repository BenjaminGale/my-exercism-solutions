(defpackage :high-scores
  (:use :cl)
  (:export :make-high-scores-table :add-player
           :set-score :get-score :remove-player))

(in-package :high-scores)

(defun make-high-scores-table ()
  (make-hash-table))

(defun add-player (high-scores player-name)
  (setf (gethash player-name high-scores) 0))

(defun set-score (high-scores player-name score)
  (setf (gethash player-name high-scores) score))

(defun get-score (high-scores player-name)
  (gethash player-name high-scores 0))

(defun remove-player (high-scores player-name)
  (remhash player-name high-scores))
